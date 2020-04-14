using BinaryTree.API.Models;
using BinaryTree.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BinaryTree.API.Controllers
{
    [ApiController]
    [Route("api/binary-tree")]
    [Produces("application/json")]
    public class BTreeController : ControllerBase
    {
        private readonly IBTreeService _binaryTreeService;

        public BTreeController(IBTreeService binaryTreeService)
        {
            _binaryTreeService = binaryTreeService;
        }

        [HttpPost]
        public async Task<ActionResult<BTreeListResponseDTO>> CreateBinaryTreeFromIntList([FromBody] BTreeListRequestDTO binaryListTree)
        {
            try
            {
                BTreeListResponseDTO binaryTreeListResponse = await _binaryTreeService.CreateBTreeFromListAsync(binaryListTree);
                return Ok(binaryTreeListResponse);
            }
            catch (ArgumentNullException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return Problem(e.Message, null, 500);
            }
        }

        [HttpGet("lowest-common-ancestor/{uuid}/{numberA}/{numberB}")]
        public async Task<ActionResult<BTreeLowestCommonAncestorResponseDTO>> GetLowestCommonAncestor(
            [FromServices] BTreeLowestCommonAncestorRequestDTO modelDto, string uuid, int numberA, int numberB)
        {
            try
            {
                modelDto.UUID = uuid;
                modelDto.NumberA = numberA;
                modelDto.NumberB = numberB;

                BTreeLowestCommonAncestorResponseDTO response = await _binaryTreeService.GetBTreeLowestCommonAncestorAsync(modelDto);

                return Ok(response);
            }
            catch(NullReferenceException e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return Problem(e.Message, null, 500);
            }
        }
    }
}
