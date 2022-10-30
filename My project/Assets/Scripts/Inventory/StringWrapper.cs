using UnityEngine;

public class StringWrapper : Countable<Strings>
{
    public static GuitarAssembly assembly;
    public StringWrapper(Strings thisString, int stock) : base(thisString, stock) {}

    public override bool UseStock() {
        bool noneLeft = base.UseStock();
        assembly.AddString(data);
        return noneLeft;
    }
    public string GetStringName() {
        return Utilities.NotesToString(data.note);
    }

    public Sprite GetStringSprite() {
        return data.image;
    }

    public Sprite GetStringIcon() {
        return data.icon;
    }
}
