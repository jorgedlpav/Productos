

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC.Data;
using MiPrimerAppMVC.Data.Repository.Interfaces;
using MiPrimerAppMVC.Models;
using System.Collections.Generic;

namespace MiPrimerAppMVC.Controllers
{
    public class ProductoController: Controller
    {

        private readonly ProductosContext _context;
        private readonly IProductoRepository _productoRepository;
/*
        public ProductoController(ProductosContext context)
        {
            _context = context;
        }
*/
        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<IActionResult> Index()
        {
            //var productos = GetData();
            //var productos = await _context.Productos.ToListAsync();
            var productos = await _productoRepository.GetAll();
            return View(productos);
        }
        //Get: localhost:puerto/Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        //Post localhost:puerto/Producto/Create
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if(ModelState.IsValid)
            {
                // Agregar logica para Grabar en BD
                //producto.FechaDeAlta = DateTime.Now;
                //_context.Add(producto);
                //await _context.SaveChangesAsync();
                var result = await _productoRepository.Create(producto);
                if(result < 0)
                {
                        ViewBag.ErrorMessage = "Error al guaedar mensajes";
                        return View(producto);
                }
                return RedirectToAction(nameof(Index));

            }
            ViewBag.ErrorMessage = "modelo no valido";
            return View(producto);
           
        }
        // GET localhost:puerto/Edit/2

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(id == 0)
                return NotFound();
            //var producto = await _context.Productos.FindAsync(id);
             var producto = await _productoRepository.GetById(id);
            //var producto1 = await _context.Productos.FirstOrDefaultAsync(p => p.Id==id);
            if(producto == null)
                return NotFound();
            return View(producto);

        }
        //Post localhost:puerto/Producto/Edit/2
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if(id != producto.Id)
                return NotFound();
            //var producto = await _context.Productos.FindAsync(id);
            //var producto1 = await _context.Productos.FirstOrDefaultAsync(p => p.Id==id);
            if(ModelState.IsValid)
            {
                //_context.Update(producto);
                //await _context.SaveChangesAsync();
                var result = await _productoRepository.Update(producto);
                if(result < 0)
                {
                        ViewBag.ErrorMessage = "Error al guaedar mensajes";
                        return View(producto);
                }
                ViewBag.ErrorMessage = "modelo no valido";
                return RedirectToAction(nameof(Index));
            }
                
            return View(producto);

        }
        // GET localhost:puerto/Delete/2
        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
                return NotFound();
            //var producto = await _context.Productos.FindAsync(id);
            var producto = _productoRepository.GetById(id);
            //var producto1 = await _context.Productos.FirstOrDefaultAsync(p => p.Id==id);
            if(producto == null)
                return NotFound();
            return View(producto);

        }
        //Post localhost:puerto/Producto/Delete/2
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
             //var producto = await _context.Productos.FindAsync(id);
            //var producto1 = await _context.Productos.FirstOrDefaultAsync(p => p.Id==id);
            //_context.Productos.Remove(producto);

            var result = await _productoRepository.DeleteById(id);
            if(result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ErrorMessage = "Error al borrar producto";
                return View();
            }
            
            

           
        }

        public List<Producto> GetData()
        {
            List<Producto> productos = new List<Producto>();
    
             productos.Add( new Producto{Id =1, Nombre = "Cafe", Descripcion = "Cafe en grano", Precio = 201.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1)});
             productos.Add( new Producto{Id =2, Nombre = "Cafe colombiano", Descripcion = "Cafe en grano tipo colombiano", Precio = 221.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1)});
             productos.Add( new Producto{Id =3, Nombre = "Cafe Sumatra", Descripcion = "Cafe en grano tipo sumatra", Precio = 231.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1)});
             productos.Add( new Producto{Id =4, Nombre = "Cafe molido", Descripcion = "Cafe en molido fino ", Precio = 241.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1)});
             productos.Add( new Producto{Id =5, Nombre = "Cafe molido", Descripcion = "Cafe en molido medio", Precio = 261.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1)});
             productos.Add( new Producto{Id =6, Nombre = "Leche Almendras", Descripcion = "Leche de Almendras", Precio = 301.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1)});
             productos.Add( new Producto{Id =7, Nombre = "Leche", Descripcion = "Leche Natural de Vaca", Precio = 401.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1)});
             productos.Add( new Producto{Id =8, Nombre = "Botella de Agua", Descripcion = "Botella de Agua 500ml", Precio = 801.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1)});
            return productos;
        }
    }
}