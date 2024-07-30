﻿using System;

namespace HealthMed.Application.DTO
{
    public class EventoDTO
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}