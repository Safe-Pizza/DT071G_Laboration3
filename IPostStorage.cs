/**
 * Filnamn: IPostStorage.cs
 * Författare: Hanna Lindkvist
 * Datum: 2026-10-01
 * Kurs: DT071G
 * 
 * Beskrivning: Interface för lagring av inlägg i gästboken.
 * 
 * **/

namespace Laboration3
{
    public interface IPostStorage
    {
        List<Post> Load();

        void Save(List<Post> posts);
    }
}
