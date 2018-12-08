import React, {Component} from 'react';
import Main from './Main';
//todo: make svg logo and call it from here
// import logo from './logo.svg';
import './App.css';
import {createMuiTheme, MuiThemeProvider} from '@material-ui/core/styles';


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

    }
);


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
