using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;
using DevIO.Bussiness.Interfaces;
using AutoMapper;
using DevIO.Bussiness.Models;

namespace DevIO.App.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository context, IMapper mapper)
        {
            _fornecedorRepository = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos()));
        }


        public async Task<IActionResult> Details(Guid id)
        {

            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorRepository.Adicionar(fornecedor);

            return View("Index");
        }

        //// GET: Fornecedor/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var fornecedorViewModel = await _context.FornecedorViewModel.FindAsync(id);
        //    if (fornecedorViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(fornecedorViewModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Documento,TipoFornecedor,Ativo")] FornecedorViewModel fornecedorViewModel)
        //{
        //    if (id != fornecedorViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(fornecedorViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FornecedorViewModelExists(fornecedorViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(fornecedorViewModel);
        //}

        //// GET: Fornecedor/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var fornecedorViewModel = await _context.FornecedorViewModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (fornecedorViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(fornecedorViewModel);
        //}

        //// POST: Fornecedor/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var fornecedorViewModel = await _context.FornecedorViewModel.FindAsync(id);
        //    _context.FornecedorViewModel.Remove(fornecedorViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool FornecedorViewModelExists(Guid id)
        //{
        //    return _context.FornecedorViewModel.Any(e => e.Id == id);
        //}

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }
    }
}
