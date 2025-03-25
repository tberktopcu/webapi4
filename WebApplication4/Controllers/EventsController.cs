﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        public EventsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = context.Events.OrderByDescending(e => e.Id).ToList();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var evt = context.Events.Find(id);
            if(evt == null)
            {
                return NotFound();
            }
            return Ok(evt);
        }

        [HttpPost]
        public IActionResult CreateEvent(EventDto eventDto)
        {
            var evt = new Event
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                Start = eventDto.Start,
                End = eventDto.End,
                AllDay = eventDto.AllDay,
                CreatedAt = DateTime.Now,
            };

            context.Events.Add(evt);
            context.SaveChanges();

            return Ok(evt);
        }

        [HttpPut("{id}")]
        public IActionResult EditEvent(int id, EventDto eventDto)
        {
            var evt = context.Events.Find(id);
            if(evt == null)
            {
                return NotFound();
            }

            evt.Title = eventDto.Title;
            evt.Description = eventDto.Description;
            evt.Start = eventDto.Start;
            evt.End = eventDto.End;
            evt.AllDay = eventDto.AllDay;

            context.SaveChanges();

            return Ok(evt);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var evt = context.Events.Find(id);
            if(evt==null)
            {
                return NotFound();
            }

            context.Events.Remove(evt);
            context.SaveChanges();

            return Ok("Event Deleted");
        }
    }
}
