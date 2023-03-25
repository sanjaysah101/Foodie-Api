using System.ComponentModel.DataAnnotations;
using Foodie_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Foodie_Api.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? Images { get; set; }
        public string? Tags { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Items> Items { get; set; }
    }
}