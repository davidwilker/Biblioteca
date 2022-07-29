﻿using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteSevice;
        public ClienteController(IClienteService clienteService)
        {
            _clienteSevice = clienteService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            try
            {
                var clientes = _clienteSevice.Listar();
                return View(clientes);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome, Cpf, Email, Fone")] ClienteDto cliente)
        {
            try
            {
                _clienteSevice.Cadastrar(cliente);
                return RedirectToAction("List");

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Edit(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var cliente = _clienteSevice.PesquisarPorId(id);
            if(cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Nome, Cpf, Email, Fone, StatusClienteId")] ClienteDto cliente)
        {
            if (string.IsNullOrEmpty(cliente.Id))
            {
                return NotFound();
            }
            try
            {
                _clienteSevice.Atualizar(cliente);
                return RedirectToAction("List");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Details(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var cliente = _clienteSevice.PesquisarPorId(id);
            if(cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        public IActionResult Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var cliente = _clienteSevice.PesquisarPorId(id);
            if(cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Delete([Bind("Id, Nome, Cpf, Email, Fone, StatusClienteId")] ClienteDto cliente)
        {
            _clienteSevice.Excluir(cliente.Id);
            return RedirectToAction("List");
        }
    }
}
