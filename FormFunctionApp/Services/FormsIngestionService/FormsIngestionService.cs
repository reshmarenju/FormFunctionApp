using FormFunctionApp.Data;
using FormFunctionApp.Models;
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


        public FormsIngestionService(DataContext dbContext,GeoFormsDbContext geoFormsDbContext)
        {
            _dbContext = dbContext;
            _geoFormsDbContext = geoFormsDbContext;
        }
        public async Task StartFormIngestion(ILogger log)
        {
            // Fetch data from AppSubmittedForms based on the Recieved column (within the last 5 minutes)
          
            DateTimeOffset startTime = DateTimeOffset.UtcNow.AddMinutes(-5);
            var AppSubmittedForms = await _geoFormsDbContext.AppSubmittedForms
                .Where(f => f.Recieved >= startTime.LocalDateTime)
                .ToListAsync();
      
            foreach (var formEntry in AppSubmittedForms)
            {

                var data = formEntry.Data;
                if (!string.IsNullOrEmpty(data))
                {
                    Form formsObject = JsonConvert.DeserializeObject<Form>(data);
                    long formId = await InsertForm(formsObject);
                    await PrepareForROBs(formsObject.Robs, formId);
                    // Access the list of ROBs and do something with it
                    List<Rob> robs = formsObject.Robs;
                    // You can iterate through the list and perform operations if needed
                    foreach (var rob in robs)
                    {
                        // Process individual rob object
                        // For example: await InsertRob(rob);
                    }
                }
            }

        }
      

        private async Task<long> InsertForm(Form formToAdd)
        {
            try
            {
                await _dbContext.Forms.AddAsync(formToAdd);
                await _dbContext.SaveChangesAsync();
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting form into VPS - {ex.Message}", ex);
            }
        }
        private async Task PrepareForROBs(List<Rob> robList, long formId)
        {
            try
            {
                //foreach (var rob in robList)
                //{
                   
                    long robsId= await InsertROBS(robList, formId);
                //}
               
                
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting ROB data into VPS - {ex.Message}", ex);
            }
        }
        private async Task<long> InsertROBS(List<Rob> robList,long formId,long eventRobRowId=0)
        {
            try
            {
                Robs robs= new Robs();
                robs.FormId = formId;
                robs.EventRobsRowId = eventRobRowId;
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
        private async Task InsertROB(List<Rob> robList, long robsId)
        {
            try
            {
                foreach (var rob in robList)
                {
                    rob.RobsSFPM_RobsId = robsId;
                }

                await _dbContext.Rob.AddRangeAsync(robList);
                await _dbContext.SaveChangesAsync();

                foreach (var rob in robList)
                {
                    await InsertAllocation(rob.Allocation, rob.SFPM_RobId);
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting ROB data into VPS - {ex.Message}", ex);
            }
        }
      
        private async Task InsertAllocation(List<Allocation> allocationData, long robId)
        {
            try
            {
                foreach (var allocation in allocationData)
                {
                    allocation.RobSFPM_RobId = robId;
                    // Loop through the properties of the Allocation object
                    var properties = allocation.GetType().GetProperties();
                    foreach (var property in properties)
                    {
                        var key = property.Name;
                        var value = property.GetValue(allocation)?.ToString();

                        // Skip empty values and certain properties
                        if (!string.IsNullOrEmpty(value) && key != "fuelType" && key != "remaining")
                        {
                            // Add key-value pair to Allocation
                            allocation.text = value;
                            allocation.Name = key;
                            await _dbContext.Allocations.AddAsync(allocation);
                            await _dbContext.SaveChangesAsync();
                        }
                    }
                   
                }
                
               
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting ROB data into VPS - {ex.Message}", ex);
            }
        }
        private async Task<long> InsertEventRobs(EventROBsRow eventRobs, long formId)
        {
            try
            {
                await _dbContext.EventROBsRows.AddRangeAsync(eventRobs);
                await _dbContext.SaveChangesAsync();
                return eventRobs.SFPM_EventROBsRowId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting ROB data into VPS - {ex.Message}", ex);
            }
        }
    }
}
