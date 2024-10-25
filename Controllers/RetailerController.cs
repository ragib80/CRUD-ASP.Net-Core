using Microsoft.AspNetCore.Mvc;
using RetailerAPI.Data;
using RetailerAPI.Models.Domain;
using RetailerAPI.Models.DTO;


namespace RetailerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetailerController : ControllerBase
    {
        private readonly RetailerDbContext dbContext;

        public RetailerController(RetailerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var retailersDomain = dbContext.Retailers.ToList();

            var retailersDto=new List<RetailerDto>();

            foreach (var retailerDomain in retailersDomain)
            {
                retailersDto.Add(new RetailerDto()
                {
                    Id = retailerDomain.Id,
                    Name = retailerDomain.Name,
                    Description = retailerDomain.Description,
                    Phone = retailerDomain.Phone,
                    Email = retailerDomain.Email

                });
            }

            return Ok(retailersDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) 
        {
            var retailerDomain = dbContext.Retailers.FirstOrDefault(x=>x.Id==id);

            if (retailerDomain == null)
            {
                return NotFound();
            }

            var retailersDto=new RetailerDto
            {
                Id = retailerDomain.Id,
                Name = retailerDomain.Name,
                Description = retailerDomain.Description,
                Phone = retailerDomain.Phone,
                Email = retailerDomain.Email
            };

            return Ok(retailersDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddRetailerRequestDto addRetailerRequestDto )
        {
            var retailerDomainModel = new Retailer
            {
                Name = addRetailerRequestDto.Name,
                Description = addRetailerRequestDto.Description,
                Phone = addRetailerRequestDto.Phone,
                Email = addRetailerRequestDto.Email
            };

            dbContext.Retailers.Add(retailerDomainModel);
            dbContext.SaveChanges();

            var retailerDto = new RetailerDto
            {
                Id=retailerDomainModel.Id,
                Name = retailerDomainModel.Name,
                Description = retailerDomainModel.Description,
                Phone = retailerDomainModel.Phone,
                Email = retailerDomainModel.Email
            };

            return CreatedAtAction(nameof(GetById), new { id = retailerDto.Id}, retailerDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRetailerRequestDto updateRetailerRequestDto)
        {
            var retailerDomainModel = dbContext.Retailers.FirstOrDefault(x => x.Id == id);

            if (retailerDomainModel == null)
            {
                return NotFound();
            }
            retailerDomainModel.Name = updateRetailerRequestDto.Name;
            retailerDomainModel.Description = updateRetailerRequestDto.Description;
            retailerDomainModel.Phone = updateRetailerRequestDto.Phone;
            retailerDomainModel.Email= updateRetailerRequestDto.Email;

            dbContext.SaveChanges();

            var retailerDto= new RetailerDto
            {
                Id = retailerDomainModel.Id,
                Name = retailerDomainModel.Name,
                Description = retailerDomainModel.Description,
                Phone = retailerDomainModel.Phone,
                Email = retailerDomainModel.Email
            };

            return Ok(retailerDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult Delete([FromRoute] Guid id)
        {
            var retailerDomainModel = dbContext.Retailers.FirstOrDefault(x => x.Id == id);

            if(retailerDomainModel == null)
            {
                return NotFound();
            }

            dbContext.Retailers.Remove(retailerDomainModel);
            dbContext.SaveChanges();

            var retailerDto = new RetailerDto
            {
                Id = retailerDomainModel.Id,
                Name = retailerDomainModel.Name,
                Description = retailerDomainModel.Description,
                Phone = retailerDomainModel.Phone,
                Email = retailerDomainModel.Email
            };

            return Ok(retailerDto);
        }
    }
}
