import React from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';

const styles = theme => ({
    nomatch: {
        ...theme.mixins.gutters(),
        paddingTop: theme.spacing.unit * 2,
        paddingBottom: theme.spacing.unit * 2,
        margin: 'auto'
    },
});

function NoMatch(props) {
    const {classes} = props;

    return (
        <div>
            <Paper className={classes.nomatch} elevation={1}>
                <Typography variant="h1" component="h3">
                    Error 404!
                </Typography>
                <Typography component="h3">
                    This page could not be found.
                </Typography>
            </Paper>
        </div>
    );
}

NoMatch.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(NoMatch);