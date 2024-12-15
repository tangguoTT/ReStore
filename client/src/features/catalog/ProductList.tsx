import {Grid2} from "@mui/material";
import {Product} from "../../app/models/Product.ts";
import ProductCard from "./ProductCard.tsx";

interface Props {
    products: Product[];
}

function ProductList({products}: Props) {

    return (
        <>
            <Grid2 container spacing={4}>
                {products.map((product) => (
                    <Grid2 key={product.id} size={{xs: 3}}>
                        <ProductCard key={product.id} product={product}/>
                    </Grid2>
                ))}
            </Grid2>
        </>
    )
}

export default ProductList;