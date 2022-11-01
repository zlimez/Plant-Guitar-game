using System;

public class Countable<U>
{
    public U data;
    public int stock;

    public Countable() {}

    public Countable(U data, int stock) {
        this.data = data;
        this.stock = stock;
    }

    public void AddToStock() {
        this.stock += 1;
    }

    public virtual bool UseStock() {
        this.stock = Math.Max(this.stock - 1, 0);
        return this.stock == 0;
    }
}
