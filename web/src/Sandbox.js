import React, {Component} from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography'
import {Link} from "react-router-dom";
import IconButton from "@material-ui/core/IconButton/IconButton";
import Unity, {UnityContent} from "react-unity-webgl";
import KeyboardArrowLeft from '@material-ui/icons/KeyboardArrowLeft'
import Grid from '@material-ui/core/Grid';
import SearchIcon from "@material-ui/core/SvgIcon/SvgIcon";
import InputBase from "@material-ui/core/InputBase";
import {fade} from "@material-ui/core/styles/colorManipulator";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";

const styles = theme => ({
    root: {

        backgroundColor: theme.palette.secondary.main,

        width: '100%',
        height: '100%'
//        overflowY: 'hidden'
    },
    sandBoxContainer: {
        flexGrow: 1,
        flex: '0 1 auto',
        alignContent: 'flex-start',
        justifyContent: 'flex-start',
        height: '100%'

    },
    nameIcon: {
        fontSize: 52,
        backgroundColor: theme.palette.primary.main,
    },
    equation: {
        padding: theme.spacing.unit,
        textAlign: 'center',
    },
    restOfContent: {
        backgroundColor: theme.palette.secondary.main,
    },
    simulation: {
        border: 'black solid 1%',
        backgroundColor: theme.palette.primary.main,

    },
    grow: {
        flexGrow: 1,
    },
    menuButton: {
        marginLeft: -12,
        marginRight: 20,
    },
    title: {
        display: 'none',
        [theme.breakpoints.up('sm')]: {
            display: 'block',
        },
    },
    search: {
        position: 'relative',
        borderRadius: theme.shape.borderRadius,
        backgroundColor: fade(theme.palette.common.white, 0.15),
        '&:hover': {
            backgroundColor: fade(theme.palette.common.white, 0.25),
        },
        marginLeft: 0,
        width: '100%',
        [theme.breakpoints.up('sm')]: {
            marginLeft: theme.spacing.unit,
            width: 'auto',
        },
    },
    searchIcon: {
        width: theme.spacing.unit * 9,
        height: '100%',
        position: 'absolute',
        pointerEvents: 'none',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    inputRoot: {
        color: 'inherit',
        width: '100%',
    },
    inputInput: {
        paddingTop: theme.spacing.unit,
        paddingRight: theme.spacing.unit,
        paddingBottom: theme.spacing.unit,
        paddingLeft: theme.spacing.unit * 10,
        transition: theme.transitions.create('width'),
        width: '100%',
        [theme.breakpoints.up('sm')]: {
            width: 120,
            '&:focus': {
                width: 200,
            },
        }
    },
    /* unity:{
         width: '80%',
         margin: 'auto',
         height: '80%'
     },*/

});

class Sandbox extends Component {
    constructor(props) {
        super(props);
        this.speed = 30;
        this.unityContent = new UnityContent(
            "Build/Build/Build.json",
            "Build/Build/UnityLoader.js", {
                adjustOnWindowResize: true
            }
        );


        this.unityContent.on("Say", message => {
            console.log("Wow Unity said: " + message);
        });

        this.unityContent.on("SendRotation", rotation => {
            this.setState({rotation: Math.round(rotation)});
        });

        this.unityContent.on("progress", progression => {
            console.log("Unity progress", progression);
        });

        this.unityContent.on("loaded", () => {
            console.log("Yay! Unity is loaded!");
        });
    }

    onClickStart() {
        this.unityContent.send("mesh-crate", "StartRotation");
    }

    onClickStop() {
        this.unityContent.send("mesh-crate", "StopRotation");
    }

    onClickUpdateSpeed(speed) {
        this.speed += speed;
        this.unityContent.send("mesh-crate", "SetRotationSpeed", this.speed);
    }

    render() {
        const {classes} = this.props;

        return (
            <div className={classes.root}>
                <Grid container className={classes.sandBoxContainer}>
                    <Grid item xs={12}>
                        <AppBar position="static">
                            <Toolbar>
                                <Link to={'/home'}>
                                    <IconButton className={classes.menuButton} color="inherit" aria-label="Open drawer">
                                        <KeyboardArrowLeft/>
                                    </IconButton>
                                    <Typography className={classes.title} variant="h6" color="inherit" noWrap>
                                        SigmaTau
                                    </Typography>
                                </Link>
                                <div className={classes.grow}/>
                                <div className={classes.search}>
                                    <div className={classes.searchIcon}>
                                        <SearchIcon/>
                                    </div>
                                    <InputBase
                                        placeholder="Search…"
                                        classes={{
                                            root: classes.inputRoot,
                                            input: classes.inputInput,
                                        }}
                                    />
                                </div>
                            </Toolbar>
                        </AppBar>
                    </Grid>
                    <Grid item xs={12}>
                        <Typography variant="h3">
                            {this.props.name} Module
                        </Typography>
                    </Grid>
                    <Grid item>
                        <div className={classes.equation}>
                            Equation here!
                        </div>
                    </Grid>
                    <Grid item xs={12} className={classes.simulation}>
                        <button onClick={this.onClickStart.bind(this)}>{"Start"}</button>
                        <button onClick={this.onClickStop.bind(this)}>{"Stop"}</button>
                        <button onClick={this.onClickUpdateSpeed.bind(this, 10)}>
                            {"Faster"}
                        </button>
                        <button onClick={this.onClickUpdateSpeed.bind(this, -10)}>
                            {"Slower"}
                        </button>
                        <Unity unityContent={this.unityContent} height="90%" width="100%"/>
                    </Grid>
                </Grid>
            </div>
        )
            ;
    }
}

Sandbox.propTypes = {
    classes: PropTypes.object.isRequired,
};
export default withStyles(styles, {withTheme: true})(Sandbox);