using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NewBeginnings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewBeginnings.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public ParticipantController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // GET api/<ParticipantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Participant participant;
            if (_memoryCache.TryGetValue(id, out participant))
            {
                return new JsonResult(participant);
            }
            return new NoContentResult();
        }

        // POST api/<ParticipantController>
        [HttpPost]
        public IActionResult Post([FromBody] Participant participant)
        {
            if(participant != null)
            {
                var cacheOptions = new MemoryCacheEntryOptions()
          .SetSlidingExpiration(TimeSpan.FromMinutes(30));

                // Set object in cache
                _memoryCache.Set(participant.ReferenceNumber, participant, cacheOptions);

                return new JsonResult(participant);
            }
            
            return new NoContentResult();
        }

        // PUT api/<ParticipantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Participant participant)
        {
            if (participant != null)
            {
                Participant existingParticipant;
                if (_memoryCache.TryGetValue(id, out existingParticipant))
                {
                    _memoryCache.Remove(id);
                }

                var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(30));

                // Set object in cache
                _memoryCache.Set(participant.ReferenceNumber, participant, cacheOptions);

                return new JsonResult(participant);
            }

            return new NoContentResult();
        }

        // DELETE api/<ParticipantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _memoryCache.Remove(id);
            return new OkResult();
        }
    }
}
