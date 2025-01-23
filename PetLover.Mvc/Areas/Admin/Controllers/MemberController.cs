using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetLover.Bl.Dtos;
using PetLover.Bl.Services.Abstraction;

namespace PetLover.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly IMemberService _service;
        private readonly IMapper _mapper;

        public MemberController(IMemberService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAll();
            return View(result);
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberDto createMemberDto)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(createMemberDto);
                return RedirectToAction(nameof(Index));
            }

            return View(createMemberDto);
        }
        public async Task<IActionResult> Update(int id)
        {
           var result=await _service.GetById(id);
            var updatedMember=_mapper.Map<UpdateMemberDto>(result);
            return View(updatedMember);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMemberDto updateMemberDto)
        {
            if (ModelState.IsValid)
            {
                await _service.Update(updateMemberDto);
                return RedirectToAction(nameof(Index));
            }

            return View(updateMemberDto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
           
          await  _service.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
