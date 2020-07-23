using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementNotesApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// App Mock Data Base
        /// </summary>
        static readonly List<Note> _notes = new List<Note>
        {
            new Note { Id = 1, TextNote = "First note!" },
            new Note { Id = 2, TextNote = "Second note!" },
        };

        // GET: api/notes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_notes);
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var note = GetCurrentNote(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        // POST api/notes
        [HttpPost]
        public IActionResult Post(Note note)
        {
            // Apply unique Id to new note
            note.Id = UniqueId();

            // andd note to db
            _notes.Add(note);

            return Ok(note);
        }

        // PUT api/notes/5
        [HttpPut("{id}")]
        public IActionResult Put(Note note)
        {
            // Associate current note with model note
            var noteDb = _notes.Where(x => x.Id == note.Id).FirstOrDefault();

            if (noteDb == null)
            {
                return NotFound();
            }
            else
            {
                // Update text of the current note
                noteDb.TextNote = note.TextNote;
            }

            return Ok(note);
        }

        // DELETE api/notes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var currentNote = GetCurrentNote(id);

            if (currentNote == null)
            {
                return NotFound();
            }

            _notes.Remove(currentNote);

            return Ok(currentNote);
        }

        /// <summary>
        /// Apply Unique Id to all next notes
        /// </summary>
        /// <returns>Unique Id</returns>
        int UniqueId() => _notes.Count != 0 ? (_notes.Select(x => x.Id).Max() + 1) : 1;

        /// <summary>
        /// Find Note that match current Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return mached Note</returns>
        Note GetCurrentNote(int id)
        {
            return _notes.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
