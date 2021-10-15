using Core.Entita;
using Core.Interfacce;
using GestioneOrdiniClienti;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdiniController : ControllerBase
    {
        private IBusinessLayer businessLayer;
        public OrdiniController(IBusinessLayer b)
        {
            businessLayer = b;
        }

        #region ORDINI

        [HttpGet]
        public ActionResult GetOrdini()
        {
            var result = businessLayer.GetAllOrdini();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetOrdineById(int id)
        {
            if (id <= 0)
                return BadRequest("invalid id");
            var ordine = businessLayer.GetOrdineById(id);
            if (ordine == null)
                return NotFound("order not found");
            return Ok(ordine);
        }

        [HttpPost]
        public ActionResult AddOrdine([FromBody] Ordine ordine)
        {
            if (ordine == null)
                return BadRequest("invalid data");
            var created = businessLayer.CreateNewOrdine(ordine);
            if (created == false)
                return StatusCode(500, "internal error");
            return CreatedAtAction(created.ToString(), ordine);
        }

        [HttpPut("{id}")]
        public ActionResult EditOrdine(int id, [FromBody]Ordine ordine)
        {
            if (id <= 0)
                return BadRequest("invalid id");
            var edited = businessLayer.EditOrdine(ordine);

            if (edited==false)
                return StatusCode(500, "internal error");

            return Ok(edited);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrdine(int id)
        {
            if (id <= 0)
                return BadRequest("invalid id");

            var result = businessLayer.DeleteOrdineById(id);
            return Ok(result);
        }
        #endregion

        #region CLIENTI
        [HttpGet("clienti")]
        public ActionResult GetClienti()
        {
            var result = businessLayer.GetAllClienti();
            return Ok(result);
        }

        [HttpGet("clienti/{id}")]
        public ActionResult GetClienteById(int id)
        {
            if (id <= 0)
                return BadRequest("invalid id");
            var cliente = businessLayer.GetClienteById(id);
            if (cliente == null)
                return NotFound("customer not found");
            return Ok(cliente);
        }

        [HttpPost("clienti")]
        public ActionResult AddCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest("invalid data");
            var created = businessLayer.CreateNewCliente(cliente);
            if (created == false)
                return StatusCode(500, "internal error");
            return CreatedAtAction(created.ToString(), cliente);
        }

        [HttpPut("cliente/{id}")]
        public ActionResult EditCliente(int id, [FromBody] Cliente cliente)
        {
            if (id <= 0)
                return BadRequest("invalid id");
            var edited = businessLayer.EditCliente(cliente);

            if (edited == false)
                return StatusCode(500, "internal error");

            return Ok(edited);
        }

        [HttpDelete("cliente/{id}")]
        public ActionResult DeleteCliente(int id)
        {
            if (id <= 0)
                return BadRequest("invalid id");

            var result = businessLayer.DeleteClienteById(id);
            return Ok(result);
        }
        #endregion
    }
}
