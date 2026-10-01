/**
 * Filnamn: Post.cs
 * Författare: Hanna Lindkvist
 * Datum: 2026-10-01
 * Kurs: DT071G
 * 
 * Beskrivning: Publik klass Post för inlägg i gästboken med properties författare (Author) och meddelande (Message).
 * 
 * **/

using System;

namespace Laboration3
{
    public class Post
    {
        public string? Author { get; set; }
        public string? Message { get; set; }
    }
}


