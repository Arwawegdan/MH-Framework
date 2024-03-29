﻿namespace MHFramework.Server;
public class BaseController<TEntity, TViewModel> : ControllerBase
    where TEntity : BaseEntity
    where TViewModel : BaseViewModel
{
    private readonly IBaseUnitOfWork<TEntity, TViewModel> _unitOfWork;
    public BaseController(IBaseUnitOfWork<TEntity, TViewModel> unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        IEnumerable<TViewModel> viewModels = await _unitOfWork.Read();
        return Ok(viewModels);
    }

    [HttpGet("id")]
    public virtual async Task<IActionResult> Get(Guid id)
    {
        TViewModel viewModel = await _unitOfWork.Read(id);
        return Ok(viewModel);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post(TViewModel viewModel)
    {
        if (viewModel == null)
            return BadRequest("ViewModel can not be null");

        viewModel = await _unitOfWork.Create(viewModel);
        
        return Ok(viewModel);
    }

    [HttpPut]
    public virtual async Task<IActionResult> Put(TViewModel viewModel)
    {

        if (viewModel == null)
            return BadRequest("ViewModel can not be null");
        
        viewModel = await _unitOfWork.Update(viewModel);

        return Ok(viewModel);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(Guid id)
    {
        TViewModel viewModel = await _unitOfWork.Delete(id);
        return Ok(viewModel);
    }
    
}