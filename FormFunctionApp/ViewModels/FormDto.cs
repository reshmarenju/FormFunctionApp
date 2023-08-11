using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FormFunctionApp.Models;

namespace FormFunctionApp.Dtos
{
    public class EmAtSeaEventType
    {
        [JsonPropertyName("ematseaactivity")]
        public string Ematseaactivity { get; set; }

        [JsonPropertyName("observeddistance")]
        public string Observeddistance { get; set; }

        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }

        [JsonPropertyName("windforce")]
        public string Windforce { get; set; }

        [JsonPropertyName("seastate")]
        public string Seastate { get; set; }

        [JsonPropertyName("OrderSpeed")]
        public string OrderSpeed { get; set; }

        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }

        [JsonPropertyName("emAtSeaEventTypesEventRobs")]
        public List<EmAtSeaEventTypesEventRob> EmAtSeaEventTypesEventRobs { get; set; }
    }

    public class EmAtSeaEventTypesEventRob
    {
        [JsonPropertyName("fuelType")]
        public string FuelType { get; set; }

        [JsonPropertyName("robstart")]
        public string Robstart { get; set; }

        [JsonPropertyName("robend")]
        public string Robend { get; set; }

        [JsonPropertyName("propulsion")]
        public string Propulsion { get; set; }

        [JsonPropertyName("maneuver")]
        public string Maneuver { get; set; }

        [JsonPropertyName("generator")]
        public string Generator { get; set; }

        [JsonPropertyName("loaddischarge")]
        public string Loaddischarge { get; set; }

        [JsonPropertyName("deballast")]
        public string Deballast { get; set; }

        [JsonPropertyName("idleon")]
        public string Idleon { get; set; }

        [JsonPropertyName("idleoff")]
        public string Idleoff { get; set; }

        [JsonPropertyName("igs")]
        public string Igs { get; set; }

        [JsonPropertyName("cargoheating")]
        public string Cargoheating { get; set; }

        [JsonPropertyName("cargoheatingplus")]
        public string Cargoheatingplus { get; set; }

        [JsonPropertyName("cargoheatingplusplus")]
        public string Cargoheatingplusplus { get; set; }

        [JsonPropertyName("cooling")]
        public string Cooling { get; set; }

        [JsonPropertyName("tankCleaning")]
        public string TankCleaning { get; set; }

        [JsonPropertyName("others")]
        public string Others { get; set; }

        [JsonPropertyName("pilotflame")]
        public string Pilotflame { get; set; }

        [JsonPropertyName("mainEngineConsumption")]
        public string MainEngineConsumption { get; set; }

        [JsonPropertyName("auxEngineConsumption")]
        public string AuxEngineConsumption { get; set; }

        [JsonPropertyName("consumption")]
        public string Consumption { get; set; }

        [JsonPropertyName("adjustment")]
        public string Adjustment { get; set; }
    }

    public class FuelchangeoverDto
    {
        [JsonPropertyName("fuelgradefrom")]
        public string Fuelgradefrom { get; set; }

        [JsonPropertyName("fuelgradeto")]
        public string Fuelgradeto { get; set; }

        [JsonPropertyName("fuelchangeoverstart")]
        public DateTime Fuelchangeoverstart { get; set; }

        [JsonPropertyName("fuelchangeoverend")]
        public DateTime Fuelchangeoverend { get; set; }
    }

    public class RobDto
    {
        [JsonPropertyName("fuelType")]
        public string FuelType { get; set; }

        [JsonPropertyName("remaining")]
        public string Remaining { get; set; }

        [JsonPropertyName("propulsion")]
        public string Propulsion { get; set; }

        [JsonPropertyName("maneuver")]
        public string Maneuver { get; set; }

        [JsonPropertyName("generator")]
        public string Generator { get; set; }

        [JsonPropertyName("loaddischarge")]
        public string Loaddischarge { get; set; }

        [JsonPropertyName("deballast")]
        public string Deballast { get; set; }

        [JsonPropertyName("idleon")]
        public string Idleon { get; set; }

        [JsonPropertyName("idleoff")]
        public string Idleoff { get; set; }

        [JsonPropertyName("igs")]
        public string Igs { get; set; }

        [JsonPropertyName("cargoheating")]
        public string Cargoheating { get; set; }

        [JsonPropertyName("cargoheatingplus")]
        public string Cargoheatingplus { get; set; }

        [JsonPropertyName("cargoheatingplusplus")]
        public string Cargoheatingplusplus { get; set; }

        [JsonPropertyName("cooling")]
        public string Cooling { get; set; }

        [JsonPropertyName("tankCleaning")]
        public string TankCleaning { get; set; }

        [JsonPropertyName("others")]
        public string Others { get; set; }

        [JsonPropertyName("pilotflame")]
        public string Pilotflame { get; set; }

        [JsonPropertyName("mainEngineConsumption")]
        public string MainEngineConsumption { get; set; }

        [JsonPropertyName("auxEngineConsumption")]
        public string AuxEngineConsumption { get; set; }

        [JsonPropertyName("consumption")]
        public string Consumption { get; set; }
    }

    public class FormDto
    {
        [JsonPropertyName("imo")]
        public string Imo { get; set; }

        [JsonPropertyName("vesselName")]
        public string VesselName { get; set; }

        [JsonPropertyName("vesselCode")]
        public string VesselCode { get; set; }

        [JsonPropertyName("formIdentifier")]
        public string FormIdentifier { get; set; }

        [JsonPropertyName("refId")]
        public string RefId { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("reporttime")]
        public DateTime Reporttime { get; set; }

        [JsonPropertyName("voyagenumber")]
        public string Voyagenumber { get; set; }

        [JsonPropertyName("port")]
        public string Port { get; set; }

        [JsonPropertyName("portetd")]
        public string Portetd { get; set; }

        [JsonPropertyName("mainremarks")]
        public string Mainremarks { get; set; }

        [JsonPropertyName("avgspeedsincelastreport")]
        public string Avgspeedsincelastreport { get; set; }

        [JsonPropertyName("vesselcondition")]
        public string Vesselcondition { get; set; }

        [JsonPropertyName("steaminghours")]
        public string Steaminghours { get; set; }

        [JsonPropertyName("observeddistancesincelastreport")]
        public string Observeddistancesincelastreport { get; set; }

        [JsonPropertyName("windforce")]
        public string Windforce { get; set; }

        [JsonPropertyName("airtemp")]
        public string Airtemp { get; set; }

        [JsonPropertyName("seatemp")]
        public string Seatemp { get; set; }

        [JsonPropertyName("barpressure")]
        public string Barpressure { get; set; }

        [JsonPropertyName("winddirection")]
        public string Winddirection { get; set; }

        [JsonPropertyName("hourscargotankheatingmaintained")]
        public string Hourscargotankheatingmaintained { get; set; }

        [JsonPropertyName("hourscargotankheatingincreased")]
        public string Hourscargotankheatingincreased { get; set; }

        [JsonPropertyName("hourscargotankscleaned")]
        public string Hourscargotankscleaned { get; set; }

        [JsonPropertyName("numberoftanksheated")]
        public string Numberoftanksheated { get; set; }

        [JsonPropertyName("numberoftanksheatingincreased")]
        public string Numberoftanksheatingincreased { get; set; }

        [JsonPropertyName("numberoftankscleaned")]
        public string Numberoftankscleaned { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("upcomingPorts")]
        public List<UpcomingPortDto> UpcomingPorts { get; set; }

        [JsonPropertyName("emAtSeaEventTypes")]
        public List<EmAtSeaEventType> EmAtSeaEventTypes { get; set; }

        [JsonPropertyName("emInPortEventTypes")]
        public List<object> EmInPortEventTypes { get; set; }

        [JsonPropertyName("robs")]
        public List<RobDto> Robs { get; set; }

        [JsonPropertyName("fuelchangeover")]
        public List<FuelchangeoverDto> Fuelchangeover { get; set; }
    }

    public class UpcomingPortDto
    {
        [JsonPropertyName("upcomingport")]
        public string Upcomingport { get; set; }

        [JsonPropertyName("via")]
        public string Via { get; set; }

        [JsonPropertyName("eta")]
        public DateTime Eta { get; set; }

        [JsonPropertyName("distancetogo")]
        public string Distancetogo { get; set; }

        [JsonPropertyName("projectedspeed")]
        public string Projectedspeed { get; set; }
    }

}
