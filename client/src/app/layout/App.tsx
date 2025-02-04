import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import Header from "./Header.tsx";
import {Container, createTheme, CssBaseline, ThemeProvider} from "@mui/material";
import {useState} from "react";
import {Outlet} from "react-router-dom";


function App() {
    
    const [darkMode, setDarkMode] = useState<boolean>(false);
    const paletteType = darkMode ? 'dark' : 'light';
    const theme = createTheme({
        palette: {
            mode: paletteType,
            background: {
                default: paletteType === 'light' ? '#eaeaea' : '#121212',
            }
        }
    });
     
    function handleThemeChange() {
        setDarkMode(!darkMode);
    }
    
    return (
        <>
            <ThemeProvider theme={theme}>
                <CssBaseline/>
                <Header darkMode={darkMode} handleThemeChange={handleThemeChange} />
                <Container>
                    <Outlet />
                </Container>
            </ThemeProvider>
        </>
    )
}

export default App
