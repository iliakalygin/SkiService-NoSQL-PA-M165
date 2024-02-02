﻿using System;
using JetStreamServiceApp.ViewModels;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JetStreamServiceApp.Models
{
    public class Order : ViewModelBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? OrderID { get; set; }

        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string? Priority { get; set; }
        public string? ServiceType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PickupDate { get; set; }
        public string Status { get; set; } = "Offen";
        public string Comment { get; set; } = "";

    }
}
