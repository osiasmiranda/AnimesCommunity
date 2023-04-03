using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.DTOs;
using SocialNetwork.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using SocialNetwork.Domain.Entites;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly UserManager<Profile> _userManager;

        public ProfilesController(IProfileService profileService, UserManager<Profile> userManager)
        {
            _profileService = profileService;
            _userManager = userManager;
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
        public async Task<ActionResult<ProfileDTO>> GetProfile(string id)
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
        public async Task<IActionResult> PutProfile(string id, ProfileDTO profileDTO)
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
            var accountId = _userManager.GetUserId;

            var profile = new ProfileDTO
            {
               AccountId = accountId.ToString(),
               FirstName = profileDTO.FirstName,
               LastName = profileDTO.LastName,
               BirthOfDay = profileDTO.BirthOfDay,
               Bio = profileDTO.Bio,
               Location = profileDTO.Location,
               ProfileImageUrl = profileDTO.ProfileImageUrl,
            };



            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _profileService.Add(profile);
            return CreatedAtAction("GetProfile", new { id = profileDTO.Id }, profileDTO);

        }
        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfileDTO>> Delete(string id)
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
