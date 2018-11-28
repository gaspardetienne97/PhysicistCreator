import React, {Component} from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography'
import Divider from '@material-ui/core/Divider'
import Drawer from './Drawers'


const styles = theme => ({
    equation: {
        border: 'black solid 1 vmin',
        backgroundColor: theme.palette.secondary.light,
        minHeight: '7vh',
        maxHeight: '10vh',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
        fontSize: 'calc(10px +2vh)',
        color: 'white',
        marginBottom: '2vh',
        marginTop: '2vh'
    },
    simulation: {
        border: 'black solid vh',
        minHeight: '75vh',
        maxHeight: '80vh',
        backgroundColor: theme.palette.primary.light,
        marginTop: '2vh',

    }
});

class Simulation extends Component {

    render() {
        const {classes} = this.props;
        return (
            <div>
                <div className={classes.equation}>
                    <Typography variant="h1">
                        Equation goes here
                    </Typography>
                </div>
                <Divider/>
                <div className={classes.simulation}>
                    <Typography variant="h1">
                        Simulation goes here
                    </Typography>
                    <Drawer/>
                </div>
            </div>
        );
    }
}


Simulation.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles, {withTheme: true})(Simulation);