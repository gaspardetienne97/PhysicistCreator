import React from 'react';
import PropTypes from 'prop-types';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import Typography from '@material-ui/core/Typography';
import InputBase from '@material-ui/core/InputBase';
import {fade} from '@material-ui/core/styles/colorManipulator';
import {withStyles} from '@material-ui/core/styles';
import SearchIcon from '@material-ui/icons/Search';
import {Link, Route, Switch} from "react-router-dom";
import NoMatch from './NoMatch'
import Home from './Home'
import Simulation from './Simulation'
import Gallery from './Modules';
import logo from './logo.svg';
import Grid from '@material-ui/core/Grid';


const styles = theme => ({
    root: {
        width: '100%',
        height: '100%',
        display: 'flex',
        flexDirection: 'column'
    },
    grow: {
        flexGrow: 1
    },
    title: {
        marginLeft: -12,
        marginRight: 20,
        display: 'none',
        [theme.breakpoints.up('sm')]: {
            display: 'block',
        },
        color: theme.palette.primary.contrastText,
        '&:hover': {
            backgroundColor: fade(theme.palette.common.white, 0.25),
        },

    },
    button: {
        minWidth: '4vw',
    },
    search: {
        position: 'relative',
        borderRadius: theme.shape.borderRadius,
        backgroundColor: fade(theme.palette.common.white, 0.15),
        '&:hover': {
            backgroundColor: fade(theme.palette.common.white, 0.25),
        },
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
        color: theme.palette.secondary.light,
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
        },
    }


});


class Main extends React.Component {
    state = {
        search: ""
    };

    render() {
        const {classes} = this.props;
        return (
            <div className={classes.root}>
                <AppBar position="static">
                    <Toolbar>
                        <Grid container>
                            <Grid item xs={4}>
                                <Link to='/' className={classes.title}>
                                    <IconButton color="inherit" aria-label="Open drawer" className={classes.button}>
                                        <img src={logo} alt={'logo'}/>
                                    </IconButton>
                                </Link>

                                <Grid item xs={8}>
                                    <Link to='/'>
                                        <Typography variant="h6" color="inherit" noWrap>
                                            SigmaTau
                                        </Typography>
                                    </Link>
                                </Grid>
                            </Grid>
                        </Grid>
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
                <Switch>
                    {/*<Route exact path='' component={Home}/>*/}
                    <Route exact path='/' component={Home}/>
                    <Route path='/home' component={Home}/>
                    <Route path='/gallery' component={Gallery}/>
                    <Route exact path='/simulation' component={Simulation}/>
                    <Route component={NoMatch}/>
                </Switch>
            </div>
        );
    }
}

Main.propTypes = {
    classes: PropTypes.object.isRequired,
    theme: PropTypes.object.isRequired,
};

export default withStyles(styles, {withTheme: true})(Main);