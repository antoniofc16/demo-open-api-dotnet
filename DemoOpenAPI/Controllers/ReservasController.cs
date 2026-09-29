using DemoOpenAPI.Data;
using DemoOpenAPI.DTO.Reserva.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoOpenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservasController : ControllerBase
    {
        public readonly IReservaService _reservaService;
        public ReservasController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        ///<summary>
        /// Obtiene la lista de reservas según los parámetros de búsqueda proporcionados.
        ///</summary>
        ///<param name="request">Fecha de busqueda</param>
        ///<response code="200">Operación exitosa</response>
        ///<response code="401">Operacion no autorizada</response>
        ///<response code="500">Error interno del servidor</response>
        [HttpGet]
        public async Task<IActionResult> GetReservas([FromQuery] ListReservaRequest request)
        {
            var result = await _reservaService.GetReservas(request);
            return Ok(result);
        }

        ///<summary>
        /// Obtiene una reserva específica por su ID.
        ///</summary>
        ///<param name="id">ID de la reserva</param>
        ///<response code="200">Operación exitosa</response>
        ///<response code="404">Reserva no encontrada</response>
        ///<response code="401">Operacion no autorizada</response>
        ///<response code="500">Error interno del servidor</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReserva(int id)
        {
            var result = await _reservaService.GetReserva(id);
            return Ok(result);
        }

        ///<summary>
        /// Crea una nueva reserva.
        ///</summary>
        ///<param name="reserva">Datos de la nueva reserva</param>
        ///<response code="201">Operación exitosa</response>
        ///<response code="400">Datos de la reserva inválidos</response>
        ///<response code="401">Operacion no autorizada</response>
        ///<response code="500">Error interno del servidor</response>
        [HttpPost]
        public async Task<IActionResult> NewReserva(NewReservaRequest reserva)
        {
            var result = await _reservaService.NewReserva(reserva);
            return Ok(result);
        }

        ///<summary>
        /// Actualiza una reserva existente.
        ///</summary>
        ///<param name="reserva">Datos de la reserva a actualizar</param>
        ///<response code="200">Operación exitosa</response>
        ///<response code="404">Reserva no encontrada</response>
        ///<response code="400">Datos de la reserva inválidos</response>
        ///<response code="401">Operacion no autorizada</response>
        ///<response code="500">Error interno del servidor</response>
        [HttpPut]
        public async Task<IActionResult> UpdateReserva(UpdateReservaRequest reserva)
        {
            var result = await _reservaService.UpdateReserva(reserva);
            return Ok(result);
        }

        ///<summary>
        /// Elimina una reserva específica por su ID.
        ///</summary>
        ///<param name="id">ID de la reserva</param>
        ///<returns>Valor booleano que indica si la operación fue exitosa</returns>
        ///<response code="200">Operación exitosa</response>
        ///<response code="404">Reserva no encontrada</response>
        ///<response code="401">Operacion no autorizada</response>
        ///<response code="500">Error interno del servidor</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var result = await _reservaService.DeleteReserva(id);
            return Ok(result);
        }
    }
}
