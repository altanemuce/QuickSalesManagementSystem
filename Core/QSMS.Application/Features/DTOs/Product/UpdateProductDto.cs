using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSMS.Application.Features.DTOs.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImageName { get; set; }
        public List<int> Categories { get; set; }
        public List<int> Tags { get; set; }
        public List<IFormFile> ImageFile { get; set; }
    }
}
