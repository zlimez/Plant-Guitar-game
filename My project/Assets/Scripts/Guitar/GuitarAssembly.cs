public class GuitarAssembly : Guitar
{
    public void AddString(int index, Strings guitarString) {
        strings[index] = guitarString;
        stringObjects[index].GetComponent<StringPlucker>().AssignString(guitarString);
    }

    public void RemoveString(int index) {
        strings[index] = null;
        stringObjects[index].GetComponent<StringPlucker>().RemoveString();
    }
}
