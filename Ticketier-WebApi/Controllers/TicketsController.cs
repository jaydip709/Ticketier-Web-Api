using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Ticketier_WebApi.Core.Context;
using Ticketier_WebApi.Core.DTO;
using Ticketier_WebApi.Core.Entities;

namespace Ticketier_WebApi.Controllers
{
    [Route("TicketierAPI/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TicketsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD

        //Create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto createTicketDto)
        {
            var newTicket = new Ticket();
            _mapper.Map(createTicketDto, newTicket);
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
            return Ok("Ticket saved successfully");
        }

        //Read all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTicketDto>>> GetTickets(string? q)
        {
            IQueryable<Ticket> query = _context.Tickets;

            if (q is not null)
            {
                query = query.Where(t=>t.PassengerName.Contains(q));
            }
            var tickets = await query.ToListAsync();
            var convertedTickets = _mapper.Map<IEnumerable<GetTicketDto>>(tickets);
            return Ok(convertedTickets);
        }

        //Read one by Id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GetTicketDto>> GetTicketById([FromRoute] int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t=>t.Id == id);
            if(ticket == null)
            {
                return NotFound("Ticket Not found");
            }
            var convertedTickets = _mapper.Map<GetTicketDto>(ticket);
            return Ok(convertedTickets);
        }

        //Update
        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditTicket([FromRoute]int id, [FromBody]UpdateTicketDto updateTicketDto)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound("Ticket Not found");
            }
            _mapper.Map(updateTicketDto, ticket);
            ticket.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(" ticket updated successfully");
        }

        //Delete
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteTask([FromRoute]int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound("Ticket Not found");
            }
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return Ok("ticket Deleted successfully");
        }
    }
}
