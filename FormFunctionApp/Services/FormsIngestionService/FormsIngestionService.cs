using AutoMapper;
using AutoMapper.Internal.Mappers;
using FormFunctionApp.Data;
using FormFunctionApp.Models;
using FormFunctionApp.Dtos;
using Microsoft.Data.SqlClient.Server;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormFunctionApp.Services.FormsIngestionService
{
    public class FormsIngestionService : IFormsIngestionService
    {
        private readonly DataContext _dbContext;
        private readonly GeoFormsDbContext _geoFormsDbContext;
        private readonly IMapper _mapper;


        public FormsIngestionService(DataContext dbContext,GeoFormsDbContext geoFormsDbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _geoFormsDbContext = geoFormsDbContext;
            _mapper = mapper;
        }
        public async Task StartFormIngestion(ILogger log)
        {
            // Fetch data from AppSubmittedForms based on the Recieved column (within the last 5 minutes)
          
            DateTimeOffset startTime = DateTimeOffset.UtcNow.AddHours(-10);
            var AppSubmittedForms = await _geoFormsDbContext.AppSubmittedForms
                .Where(f => f.Recieved >= startTime.LocalDateTime)
                .ToListAsync();
      
            foreach (var formEntry in AppSubmittedForms)
            {

                var data = formEntry.Data;
                if (!string.IsNullOrEmpty(data))
                {
                    FormDto formsObject = JsonConvert.DeserializeObject<FormDto>(data);
                    Form form =_mapper.Map<Form>(formsObject);
                    List<Rob> robs = _mapper.Map<List<Rob>>(formsObject.Robs);
                    List<EventROBsRow> eventROBs = _mapper.Map<List<EventROBsRow>>(formsObject.EmAtSeaEventTypes);

                    long formId = await InsertForm(form);
                    if(robs.Any())
                    {
                        long robsId = await InsertROBS(formsObject.Robs, formId);
                    }
                    if (eventROBs.Any())
                    {
                        long eventRobsId = await InsertEventRobs(formsObject.EmAtSeaEventTypes, formId);
                    }
                    


                    //   await PrepareForROBs(formsObject.Robs, formId);

                    //     List<Rob> robs = formsObject.Robs;


                }
            }

        }
       
        private async Task<long> InsertForm(Form formToAdd)
        {
            try
            {
                await _dbContext.Forms.AddRangeAsync(formToAdd);
                _dbContext.SaveChanges();
                return formToAdd.SFPM_Form_Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting form into VPS - {ex.Message}", ex);
            }
        }
       
        private async Task<long> InsertROBS(List<RobDto> robList,long formId,long eventRobRowId=0)
        {
            try
            {
                Robs robs= new Robs();
                robs.FormId = formId;
                if (eventRobRowId != 0)
                {
                    robs.EventRobsRowId = eventRobRowId;
                }
            
                await _dbContext.Robs.AddRangeAsync(robs);
                await _dbContext.SaveChangesAsync();
                await InsertROB(robList, robs.SFPM_RobsId);
                return robs.SFPM_RobsId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting ROB data into VPS - {ex.Message}", ex);
            }
        }
        private async Task InsertROB(List<RobDto> robDtoList, long robsId)
        {
            try
            {
                List<Rob> robObject = _mapper.Map<List<Rob>>(robDtoList);

                foreach (var rob in robObject)
                {
                    rob.RobsSFPM_RobsId = robsId;
                }

                await _dbContext.Rob.AddRangeAsync(robObject);
                await _dbContext.SaveChangesAsync();

                foreach (var (rob, robDto) in robObject.Zip(robDtoList, (r, d) => (r, d)))
                {
                    await InsertAllocation(rob, robDto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting ROB data into VPS - {ex.Message}", ex);
            }
        }

        private async Task InsertAllocation(Rob rob, RobDto robDto)
        {
            try
            {
                var allocationList = CreateAllocationList(robDto, rob);

                await _dbContext.Allocation.AddRangeAsync(allocationList);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting allocation data into VPS - {ex.Message}", ex);
            }
        }

        private List<Allocation> CreateAllocationList(RobDto robDto, Rob rob)
        {
            var allocationList = new List<Allocation>();

            foreach (var property in typeof(RobDto).GetProperties())
            {
                // Exclude specified properties and properties with null values
                if (property.Name == "FuelType" || property.Name == "Remaining" ||
                    property.Name == "MainEngineConsumption" || property.Name == "AuxEngineConsumption" ||
                    property.Name == "Consumption" || property.GetValue(robDto) == null)
                {
                    continue;
                }

                var allocation = new Allocation
                {
                    Name = property.Name,
                    text = property.GetValue(robDto).ToString(),
                    RobSFPM_RobId = rob.SFPM_RobId,
                    CreatedDateTime = DateTime.Now,
                    CreatedBy = rob.CreatedBy,
                    ModifiedBy = rob.ModifiedBy,
                    ModifiedDateTime = rob.ModifiedDateTime
                };

                allocationList.Add(allocation);
            }

            return allocationList;
        }

        private async Task<long> InsertEventRobs(List<EmAtSeaEventType> eventRobs, long formId)
        {
            try
            {
                //await _dbContext.EventROBsRows.AddRangeAsync(eventRobs);
                //await _dbContext.SaveChangesAsync();
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting ROB data into VPS - {ex.Message}", ex);
            }
        }
    }
}
