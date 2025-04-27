using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tpmodul10_103022330051.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // Static List untuk menyimpan data Mahasiswa
        private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Muhammad Zaky Al-Farizy", Nim = "103022330051" },
            new Mahasiswa { Nama = "Farrel Farista", Nim = "103022330052" },
            new Mahasiswa { Nama = "Rafly Nur Muhammad", Nim = "103022330053" }
        };

        // GET: /api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return daftarMahasiswa;
        }

        // GET: /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> Get(int index)
        {
            if (index < 0 || index >= daftarMahasiswa.Count)
            {
                return NotFound();
            }
            return daftarMahasiswa[index];
        }

        // POST: /api/mahasiswa
        [HttpPost]
        public ActionResult Post([FromBody] Mahasiswa mahasiswaBaru)
        {
            daftarMahasiswa.Add(mahasiswaBaru);
            return Ok();
        }

        // DELETE: /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= daftarMahasiswa.Count)
            {
                return NotFound();
            }
            daftarMahasiswa.RemoveAt(index);
            return Ok();
        }
    }

    public class Mahasiswa
    {
        public string Nama { get; set; }
        public string Nim { get; set; }
    }
}
