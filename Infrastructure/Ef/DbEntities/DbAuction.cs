﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Ef.DbEntities;

public class DbAuction
{
    public int Id { get; set; }
    

    [ForeignKey("IdUser")]
    public int IdUser { get; set; }
    public string Title { get; set; }
    
    public string Category { get; set; }
    
    public string Descri { get; set; }
    
    public string Img { get; set; }
    
    public decimal Price { get; set; }
    
    public DateTime Timer { get; set; } 
}