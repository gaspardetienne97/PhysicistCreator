import React from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import {Link} from "react-router-dom";
import Button from "@material-ui/core/Button/Button";
import Pikachu from './images/pikachu.jpg'

const styles = theme => ({
    root: {
        height: '100%',
        width: '100%',
        backgroundColor: theme.palette.secondary.main
    },
    infoBox: {
        height: "auto",
        left: 0,
        margin: "auto",
        maxWidth: 400,
        minWidth: 320,
        position: "absolute",
        right: 0,
        top: "20%",
    },

    logo: {
        borderRadius: '5%',
        border: '' + theme.palette.primary.dark + ' solid 1%',
        backgroundColor: theme.palette.primary.light,
        width: '40vmin',
        height: '40vmin',
    },
    description: {
        padding: 10,
        width: '40vmin',
        textAlign: 'justify'
    },
    button: {
        padding: 10,
        textAlign: "center"
    }
});

function NoMatch(props) {
    const {classes} = props;

    return (
        <div className={classes.root}>
            <div className={classes.infoBox}>

                <div className={classes.logo}>
                    <img src={Pikachu} className={classes.logo} alt='suprised pikachu!'/>
                </div>
                <div className={classes.description}>
                    <Typography variant="h1" component="h3">
                        Error 404!
                    </Typography>
                    <Typography component="h3">
                        The page you requested could not be found.
                    </Typography></div>
                <div className={classes.button}>
                    <Link to='/'>
                        <Button variant="contained" color="primary" className={classes.button}>Return Home!
                        </Button>
                    </Link>
                </div>
            </div>
        </div>
    );
}

NoMatch.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(NoMatch);