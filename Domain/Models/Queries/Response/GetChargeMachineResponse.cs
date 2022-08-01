﻿namespace Domain.Models.Queries.Response {

    public class GetChargeMachineResponse {
        public int Id { get; set; }
        public int Number { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

}