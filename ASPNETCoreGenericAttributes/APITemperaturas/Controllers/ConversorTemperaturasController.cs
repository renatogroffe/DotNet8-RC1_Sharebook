﻿using Microsoft.AspNetCore.Mvc;
using APITemperaturas.Models;

namespace APITemperaturas.Controllers;

[ApiController]
[Route("[controller]")]
public class ConversorTemperaturasController : ControllerBase
{
    private readonly ILogger<ConversorTemperaturasController> _logger;

    public ConversorTemperaturasController(ILogger<ConversorTemperaturasController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Fahrenheit/{temperatura}")]
    [ProducesResponseType<Temperatura>(StatusCodes.Status200OK)]
    [ProducesResponseType<FalhaCalculo>(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(Temperatura), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(FalhaCalculo), StatusCodes.Status400BadRequest)]
    public ActionResult<Temperatura> GetConversaoFahrenheit(double temperatura)
    {
        _logger.LogInformation(
            $"Recebida temperatura para conversao: {temperatura}");

        if (temperatura < -459.67)
        {
            var mensagemErro =
                $"Valor de temperatura em Fahrenheit invalido: {temperatura}";
            _logger.LogError(mensagemErro);
            return new BadRequestObjectResult(
                new FalhaCalculo()
                {
                    Mensagem = mensagemErro
                });
        }

        var resultado = new Temperatura(temperatura);
        _logger.LogInformation(
            $"{resultado.Fahrenheit} graus Fahrenheit = " +
            $"{resultado.Celsius} graus Celsius = " +
            $"{resultado.Kelvin} graus Kelvin");
        return resultado;
    }
}