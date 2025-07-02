using Database.Models.BaseTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Tnt2
{
    public class TrackingEvent_Ver_2
    {
        public string? eventID { get; set; }
        public DateTime eventCreatedDateTime { get; set; }
        public string? eventType { get; set; }
        public string? eventClassifierCode { get; set; }
        public DateTime eventDateTime { get; set; }
        public string? equipmentEventTypeCode { get; set; }
        public string? equipmentReference { get; set; }
        public string? ISOEquipmentCode { get; set; }
        public string? emptyIndicatorCode { get; set; }
        public EventLocation? eventLocation { get; set; }
        public TransportCall? transportCall { get; set; }
        public List<DocumentReference>? documentReferences { get; set; }
        public List<Seal>? seals { get; set; }
    }

    public class EventLocation
    {
        public string? locationName { get; set; }
        public string? UNLocationCode { get; set; }
    }

    public class TransportCall
    {
        public string? transportCallID { get; set; }
        public string? exportVoyageNumber { get; set; }
        public string? importVoyageNumber { get; set; }
        public int transportCallSequenceNumber { get; set; }
        public string? UNLocationCode { get; set; }
        public string? facilityCodeListProvider { get; set; }
        public string? facilityTypeCode { get; set; }
        public string? otherFacility { get; set; }
        public string? modeOfTransport { get; set; }
        public object? location { get; set; }
        public object? vessel { get; set; }
    }

    public class DocumentReference
    {
        public string? documentReferenceType { get; set; }
        public string? documentReferenceValue { get; set; }
    }

    public class Seal
    {
        public string? sealNumber { get; set; }
        public string? sealType { get; set; }
        public string? sealSource { get; set; }
    }

}
