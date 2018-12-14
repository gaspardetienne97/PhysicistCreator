import React, {Component} from 'react'
import Main from './Main';
//todo: make svg logo and call it from here
import logo from './logo.svg'
import './App.css'
import {createMuiTheme, MuiThemeProvider} from '@material-ui/core/styles'
import Homepage from './Homepage'
import {Route, Switch} from "react-router-dom"
import NoMatch from "./NoMatch"
import Sandbox from './Sandbox'

const theme = createMuiTheme({
        palette: {
            primary: {
                light: '#9a67ea',
                main: '#ffffff',
                dark: '#320b86',
                contrastText: '#000000'
            },
            secondary: {
                light: '#ffeeff',
                main: '#000000',
                dark: '#c48b9f',
                contrastText: '#ffffff'
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
                {/*<Main/>*/}
                {/*<Homepage/>*/}
                <Switch>
                    <Route exact path='/' component={Homepage}/>
                    <Route path='/home' component={Homepage}/>
                    <Route exact path='/simulation' component={Sandbox}/>
                    <Route component={NoMatch}/>
                </Switch>
            </MuiThemeProvider>
        );
    }
}

export default App;
