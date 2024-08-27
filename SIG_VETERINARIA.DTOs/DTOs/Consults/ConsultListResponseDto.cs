﻿namespace SIG_VETERINARIA.DTOs.DTOs.Consults
{
    public class ConsultListResponseDto
    {
        public int id { get; set; }
        public DateTime consult_date { get; set; }
        public string reason { get; set; } = "";
        public string antecedents { get; set; } = "";
        public string diseases { get; set; } = "";
        public DateTime next_consult { get; set; }
        public int patient_id { get; set; }
        public int totalRecords { get; set; }
    }
}
