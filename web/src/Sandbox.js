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
import logo from './logo.svg'
import red from '@material-ui/core/colors/red';
import blue from '@material-ui/core/colors/blue';
import SvgIcon from '@material-ui/core/SvgIcon';

const styles = theme => ({
    root: {
        backgroundColor: theme.palette.secondary.main,
        width: '100vw',
        height: '100vh'
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
    iconHover: {
        margin: theme.spacing.unit * 2,
        '&:hover': {
            color: red[800],
        },
    },
    /* unity:{
         width: '80%',
         margin: 'auto',
         height: '80%'
     },*/
    nameBar: {
        backgroundColor: theme.palette.primary.main,
        padding: theme.spacing.unit
    }
});

function HomeIcon(props) {
    return (
        <SvgIcon {...props}>
            <img src={logo} alt={'logo'}/>
        </SvgIcon>
    );
}

class Sandbox extends Component {
    constructor(props) {
        super(props);
        this.speed = 30;
        this.unityContent = new UnityContent(
            props.content.JSONBuild,
            props.content.UnityLoader, {
                adjustOnWindowResize: true
            }
        );
    };


    render() {
        const {classes} = this.props;

        return (
            <div className={classes.root}>
                <Grid container className={classes.sandBoxContainer}>
                    <Grid item xs={12}>
                        <AppBar position="static">
                            <Toolbar>
                                <Link to={'/home'}>
                                    <IconButton className={classes.menuButton} color="inherit" aria-label="Open drawer"><KeyboardArrowLeft/>
                                    </IconButton>
                                    <IconButton>
                                        <HomeIcon className={classes.iconHover} color="error" style={{fontSize: 30}} /></IconButton>
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
                    <Grid item xs={12} className={classes.nameBar}>
                        <Typography variant="h3">
                            {this.props.content.name} Module
                        </Typography>
                    </Grid>
                    <Grid item>
                        <div className={classes.equation}>
                            Equation here!
                        </div>
                    </Grid>
                    <Grid item xs={12} className={classes.simulation}>
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