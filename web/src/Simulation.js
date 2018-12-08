import React, {Component} from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography'
import {Link} from "react-router-dom";
import IconButton from "@material-ui/core/IconButton/IconButton";
import Unity, {UnityContent} from "react-unity-webgl";
import KeyboardArrowLeft from '@material-ui/icons/KeyboardArrowLeft'
import Grid from '@material-ui/core/Grid';

const styles = theme => ({
    root:{
        backgroundColor: theme.palette.secondary.main,
        flex: 1,
        width: '100%'
    },
    name: {
        width: '100%',
        backgroundColor: theme.palette.primary.light,
        padding: theme.spacing.unit,
        textAlign: 'left',

    },
    nameIcon: {
        fontSize: 52,
        backgroundColor: theme.palette.primary.main,
    },
    equation: {
        padding: theme.spacing.unit,
        textAlign: 'center',
    },
    restofContent: {
        backgroundColor: theme.palette.secondary.light,
    },
    simulation: {
        border: 'black solid 1%',
        backgroundColor: theme.palette.primary.light,

    },

});

class Simulation extends Component {
    constructor(props) {
        super(props);

        this.unityContent = new UnityContent(
            "UnityModules/Build/UnityModules.json",
            "UnityModules/Build/UnityLoader.js"
        );
    }

    render() {
        const {classes} = this.props;
        return (
            <div className={classes.root}>
                <Grid container className={classes.name}>
                    <Grid item xs={2} md={1} lg={1} className={classes.nameIcon}>
                        <Link to={'/gallery'}>
                            <IconButton color="inherit">
                                <KeyboardArrowLeft/>
                            </IconButton>
                        </Link>
                    </Grid>
                    <Grid item xs={10} md={11} lg={11}>
                        <Typography variant="h4">
                            {this.props.name} Module
                        </Typography>
                    </Grid>
                    <Grid item xs={12} className={classes.restofContent}>
                        <Typography variant="h1">
                            Equation goes here
                        </Typography>
                    </Grid>
                    <Grid item xs={12} className={classes.simulation}>
                        <Unity unityContent={this.unityContent}/>
                    </Grid>
                </Grid>
            </div>
        )
            ;
    }
}


Simulation.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles, {withTheme: true})(Simulation);