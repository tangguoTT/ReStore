import {Product} from "../../app/models/Product.ts";
import ProductList from "./ProductList.tsx";
import {useEffect, useState} from "react";

function Catalog() {
    
    const [products, setProducts] = useState<Product[] >([]);
    
    useEffect(() => {
        fetch('http://localhost:5202/products')
            .then(res => res.json())
            .then(data => setProducts(data))
    }, [])
 
    return (
        <>
            <ProductList products={products}/>
        </>
    )
}

export default Catalog;