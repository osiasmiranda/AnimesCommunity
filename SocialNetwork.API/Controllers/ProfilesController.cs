using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.DTOs;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Domain.Entites;
using SocialNetwork.Infrastructure.Context;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        // GET: api/Profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileDTO>>> Get()
        {
            var profiles = await _profileService.GetProfiles();
            return Ok(profiles);
        }

        // GET: api/Profiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileDTO>> GetProfile(int id)
        {
            var profile =await _profileService.GetById(id);
            if(profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        // PUT: api/Profiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, ProfileDTO profileDTO)
        {
            if(id != profileDTO.Id)
            {
                return BadRequest();
            }
            await _profileService.Update(profileDTO);
            return Ok(profileDTO);
        }


        // POST: api/Profiles
        [HttpPost]
        public async Task<ActionResult> PostProfile(ProfileDTO profileDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _profileService.Add(profileDTO);
            return CreatedAtAction("GetProfile", new { id = profileDTO.Id }, profileDTO);

        }
        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfileDTO>> Delete(int id)
        {
            var profileDTO = await _profileService.GetById(id);
            if (profileDTO == null)
            {
                return NotFound();
            }
            await _profileService.Remove(id);
            return Ok(profileDTO);
        }
    }
}
