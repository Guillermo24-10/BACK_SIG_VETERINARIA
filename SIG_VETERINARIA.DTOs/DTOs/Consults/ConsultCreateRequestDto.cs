﻿namespace SIG_VETERINARIA.DTOs.DTOs.Consults
{
    public class ConsultCreateRequestDto
    {
        public int id { get; set; }
        public string reason { get; set; } = "";
        public string antecedents { get; set; } = "";
        public string diseases { get; set; } = "";
        public DateTime next_consult { get; set; }
        public int patient_id { get; set; }
    }
}
