import React from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import {Link} from "react-router-dom";
import Button from "@material-ui/core/Button/Button";

const styles = theme => ({
    root: {
        height: '100%',
        width: '100%',
        backgroundColor: theme.palette.secondary.main
    },
    noMatch: {
        ...theme.mixins.gutters(),
        paddingTop: theme.spacing.unit * 2,
        paddingBottom: theme.spacing.unit * 2,
        margin: 'auto'
    },
});

function NoMatch(props) {
    const {classes} = props;

    return (
        <div className={classes.root}>
            <div className={classes.noMatch}>
                <Typography variant="h1" component="h3">
                    Error 404!
                </Typography>
                <Typography component="h3">
                    This page could not be found.
                </Typography>
                <Link to='/'>
                    <Button variant="contained" color="primary" className={classes.button}>Return Home!
                    </Button>
                </Link>
            </div>
        </div>
    );
}

NoMatch.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(NoMatch);