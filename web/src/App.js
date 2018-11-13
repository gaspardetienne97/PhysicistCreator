import React, {Component} from 'react';
import Drawer from './drawer'
import logo from './logo.svg';
import './App.css';
import {MuiThemeProvider, createMuiTheme} from '@material-ui/core/styles';
import purple from '@material-ui/core/colors/purple';
import green from '@material-ui/core/colors/green';

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
                <div className="App">
                    <Drawer/>
                </div>
            </MuiThemeProvider>
        );
    }
}

export default App;
