using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetailerAPI.Data;
using RetailerAPI.Models.Domain;
using RetailerAPI.Models.DTO;
using RetailerAPI.Repositories;


namespace RetailerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetailerController : ControllerBase
    {
        private readonly IRetailerRepository retailerRepository;

        public RetailerController(IRetailerRepository retailerRepository)
        {
            this.retailerRepository = retailerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retailersDomain = await retailerRepository.GetAllAsync();

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
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            var retailerDomain = await retailerRepository.GetByIdAsync(id);

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
        public async Task<IActionResult> Create([FromBody] AddRetailerRequestDto addRetailerRequestDto )
        {
            var retailerDomainModel = new Retailer
            {
                Name = addRetailerRequestDto.Name,
                Description = addRetailerRequestDto.Description,
                Phone = addRetailerRequestDto.Phone,
                Email = addRetailerRequestDto.Email
            };

            retailerDomainModel=await retailerRepository.CreateAsync(retailerDomainModel);

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
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRetailerRequestDto updateRetailerRequestDto)
        {
            var retailerDomainModel = new Retailer
            {
                Name = updateRetailerRequestDto.Name,
                Description = updateRetailerRequestDto.Description,
                Phone = updateRetailerRequestDto.Phone,
                Email = updateRetailerRequestDto.Email
            };

            retailerDomainModel = await retailerRepository.UpdateAsync(id, retailerDomainModel);

            if (retailerDomainModel == null)
            {
                return NotFound();
            }
           
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

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var retailerDomainModel = await retailerRepository.DeleteAsync(id);

            if(retailerDomainModel == null)
            {
                return NotFound();
            }

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
