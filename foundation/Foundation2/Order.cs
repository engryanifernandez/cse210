using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private float _shippingCost;
    private float _total;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;

        if (customer.LivesInUSA())
        {
            _shippingCost = 5;
        }
        else
        {
            _shippingCost = 35;
        }
        _products = products;
        CalculateTotal();
    }

     public void CalculateTotal()
    {
        _total = _shippingCost;
        foreach (Product product in _products)
        {
            _total += product.GetTotalCost();
        }
    }

    public float GetTotal()
    {
        return _total;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.GetName()}\nProduct ID: {product.GetProductId()}\n\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = $"Shipping Label:\nCustomer: {_customer.GetName()}, Customer Address: {_customer.GetAddress()}\n";
        return shippingLabel;
    }
}
