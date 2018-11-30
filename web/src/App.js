import React, {Component} from 'react';
import Main from './Main';
//todo: make svg logo and call it from here
// import logo from './logo.svg';
import './App.css';
import {createMuiTheme, MuiThemeProvider} from '@material-ui/core/styles';


//todo: try to embed a unity scene within the app. try: npm install react-unity-webgl

const theme = createMuiTheme({
    palette: {
        primary: {
            light: '#9a67ea',
            main: '#673ab7',
            dark: '#320b86',
            contrastText: '#ffffff'
        },
        secondary: {
            light: '#ffeeff',
            main: '#f8bbd0',
            dark: '#c48b9f',
            contrastText: '#000000'
        },
    },
    typography: {
        useNextVariants: true,
    },
});
/*
todo: implement dark theme for the site.
todo: use [CTRL + D] as cheat code to activate dark theme easter egg.

const themedark = createMuiTheme({
    palette: {
        primary: {
            light: purple[300],
            main: purple[500],
            dark: purple[700],
        },
        secondary: {
            light: amber[300],
            main: amber[500],
            dark: amber[700],
        },
    },
    typography: {
        useNextVariants: true,
    },
});
*/


class App extends Component {


    render() {
        return (

            <MuiThemeProvider theme={theme}>
                    <Main/>
            </MuiThemeProvider>
    );
    }
    }

    export default App;
