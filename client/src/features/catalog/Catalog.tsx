import {Product} from "../../app/models/Product.ts";
import ProductList from "./ProductList.tsx";
import {useEffect, useState} from "react";
import agent from "../../app/api/agent.ts";
import LoadingComponent from "../../app/layout/LoadingComponent.tsx";

function Catalog() {
    
    const [products, setProducts] = useState<Product[]>([]);
    const [loading, setLoading] = useState(true);
    
    useEffect(() => {
        agent.Catalog.list().then(products => setProducts(products))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }, [])
    
    if(loading) {
        return <LoadingComponent message='Loading Products...' />
    }
    
    return ( 
        <>
            <ProductList products={products}/>
        </>
    )
}

export default Catalog;