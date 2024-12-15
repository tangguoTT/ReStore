import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import '../src/app/layout/styles.css'
import {RouterProvider} from "react-router-dom";
import {router} from "./app/router/Router.tsx";

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>
)
