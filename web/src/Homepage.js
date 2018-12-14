import React, {Component} from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography'
import Widget from "./Widget";
import Grid from "@material-ui/core/Grid";
import Placeholder from './images/Placeholder.png';

import Paper from '@material-ui/core/Paper';



const styles = theme => ({
    homeContainer: {
        flexGrow: 1,
        flex: '1 1 0',
        alignContent: 'space-evenly',
        justifyContent: 'space-around',
        height: '100%',
        width: '80%',
        margin: 'auto',
        backgroundColor: 'white'
    },
    infoBox: {
        margin: 'auto',
        justifyContent: 'space-around',
        alignContent: 'space-around',
        textAlign: 'center',
    },

    logo: {
        textAlign: 'center',
        borderRadius: '100%',
        border: '' + theme.palette.primary.dark + ' solid 1%',
        backgroundColor: 'gray',
        height: '320px',
        width: '320px',
        margin: '5% auto'
    },
    description: {
        padding: 10,
        textAlign: 'left',
        margin: '5% auto'
    },
    moduleBox: {
        alignContents: 'space-around',
        justifyContent: 'space-around',
        margin: 'auto'
    },
    widgets: {
        margin: 'auto'
    },
    color: {
        color: '#000000'
    },
    button: {
        padding: 10,
        textAlign: "center"
    },
    root: {
        height: '100%',
        width: '100%',
        backgroundColor: "white",
        padding: '50px auto'
    },
    paper: {
        padding: theme.spacing.unit * 2,
        textAlign: 'center',
        color: theme.palette.text.secondary,
    },
});
const content = {
    Math: {
        name: 'Math',
        message: '  Our math module will go here it will be comprised of the visualization of a line\n' +
            '                                        integral in 3D space',
       JSONBuild: "Build/Build/Build.json",
        UnityLoader: "Build/Build/UnityLoader.js",
    },
    Physics: {
        name: 'Physics',
        message: 'Our physics module will build upon our math module and explain flux using line\n' +
            '                                        integrals.',
        JSONBuild: "Build/Build/Build.json",
        UnityLoader: "Build/Build/UnityLoader.js",
    }
};
class Homepage extends Component {

    render() {
        const {classes} = this.props;
        return (
            <div className={classes.root}>
                <Grid container className={classes.homeContainer} >

                    <Grid item xs={12} md={6} lg={4} className={classes.infoBox}>
                        <Grid item xs={12}>
                                <div className={classes.logo}>
                                    logo
                                </div>
                        </Grid>
                        <Grid item xs={12}>
                                <div className={classes.description}>
                                    <Typography className={classes.color} variant="body1">
                                        Lorem ipsum dolor sit amet, consectetur adipisicing elit.Assumenda distinctio
                                        doloremque
                                        ducimus
                                        esse hic, illo incidunt neque perspiciatis quod repellat, repudiandae rerum sit
                                        vitae.Aut
                                        incidunt inventore iste molestiae voluptatum ?
                                    </Typography>
                                </div>
                        </Grid>
                    </Grid>
                    <Grid item xs={12} md={6} lg={8} className={classes.moduleBox}>
                            <Grid item xs={12}>
                                <Widget name={content.Math.name} message={content.Math.message} img={Placeholder}/>

                                <Widget name={content.Physics.name} message={content.Physics.message}
                                        img={Placeholder}/>
                            </Grid>
                    </Grid>
                </Grid>
            </div>
        );
    }
}

Homepage.propTypes = {
    classes: PropTypes.object.isRequired,
};


export default withStyles(styles)(Homepage);