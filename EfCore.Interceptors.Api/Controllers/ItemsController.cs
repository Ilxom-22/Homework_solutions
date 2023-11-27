using AutoMapper;
using EfCore.Interceptors.Api.Models.Dtos;
using EfCore.Interceptors.Domain.Entities;
using EfCore.Interceptors.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EfCore.Interceptors.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ItemsController(IMapper mapper, IItemRepository itemRepository) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var result = itemRepository.Get();

        return Ok(result);
    }

    [HttpGet("{itemId:guid}")]
    public async ValueTask<IActionResult> GetItemById([FromRoute] Guid itemId)
    {
        var item = await itemRepository.GetByIdAsync(itemId);
        return item != null ? Ok(item) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] ItemDto item)
    {
        var createdItem = await itemRepository.CreateAsync(mapper.Map<Item>(item));
        return Ok(mapper.Map<ItemDto>(createdItem));
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] ItemDto item)
    {
        await itemRepository.UpdateAsync(mapper.Map<Item>(item));
        return Ok();
    }

    [HttpDelete("{itemId:guid}")]
    public async ValueTask<IActionResult> DeleteByIdAsync([FromRoute] Guid itemId)
    {
        await itemRepository.DeleteByIdAsync(itemId);
        return Ok();
    }
}