import React, {Component} from 'react'
import logo from './logo.svg'
import './App.css'
import {createMuiTheme, MuiThemeProvider} from '@material-ui/core/styles'
import Homepage from './Homepage'
import {Route, Switch} from "react-router-dom"
import NoMatch from "./NoMatch"
import Sandbox from './Sandbox'
import content from './Content'
import Widget from "./Widget";
import Placeholder from "./images/Placeholder.png";
import Grid from "@material-ui/core/Grid";

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
                <Switch>
                    <Route exact path='/' render={(props) => <Homepage {...props} content={content}/>}/>
                    <Route path='/home' render={(props) => <Homepage {...props} content={content}/>}/>


                    <Route exact path={'/'+content.VectorSinkLoop.name}
                           render={(props) => <Sandbox {...props} content={content.Math}/>}/>
                    <Route exact path={'/'+content.FaradaysLaw.name}
                           render={(props) => <Sandbox {...props} content={content.Math}/>}/>
                    <Route exact path={'/'+content.AmperesLaw.name}
                           render={(props) => <Sandbox {...props} content={content.Math}/>}/>
                    <Route exact path={'/'+content.ConstantVectorIntegralOpenLoop.name}
                           render={(props) => <Sandbox {...props} content={content.Math}/>}/>
                    <Route exact path={'/'+content.VectorLoopConstant.name}
                           render={(props) => <Sandbox {...props} content={content.Math}/>}/>
                    <Route exact path={'/'+content.VectorLoopSink.name}
                           render={(props) => <Sandbox {...props} content={content.Math}/>}/>
                    <Route exact path={'/'+content.VectorLoopDiscontinuous.name}
                           render={(props) => <Sandbox {...props} content={content.Math}/>}/>
                    <Route exact path={'/'+content.VectorOpenConstant.name}
                           render={(props) => <Sandbox {...props} content={content.Math}/>}/>
                    <Route exact path={'/'+content.ScalarOpen.name}
                           render={(props) => <Sandbox {...props} content={content.Math}/>}/>
                    <Route exact path={'/'+content.VectorClosedSink.name}
                           render={(props) => <Sandbox {...props} content={content.Math}/>}/>


                    <Route component={NoMatch}/>
                </Switch>
            </MuiThemeProvider>
        );
    }
}

export default App;
