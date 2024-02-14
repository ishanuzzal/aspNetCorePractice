using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ASP_Core_Web_Api.Models;

public partial class Order
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    [JsonIgnore]
    Manager Manager { get; set; }
    public int ManagerId { get; set; }
}
