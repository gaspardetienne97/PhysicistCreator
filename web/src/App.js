import React, {Component} from 'react';
import Main from './Main';
import logo from './logo.svg';
import './App.css';
import {MuiThemeProvider, createMuiTheme} from '@material-ui/core/styles';
import purple from '@material-ui/core/colors/purple';
import green from '@material-ui/core/colors/green';

//todo: learn how to use react-router and restructure this app.
//todo: try to embed a unity scene within the app. try: npm install react-unity-webgl

const theme = createMuiTheme({
    palette: {
        primary: {
            light: purple[300],
            main: purple[500],
            dark: purple[700],
        },
        secondary: {
            light: green[300],
            main: green[500],
            dark: green[700],
        },
    },
    typography: {
        useNextVariants: true,
    },
});


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
